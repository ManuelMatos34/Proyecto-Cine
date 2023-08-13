import React, { useState } from "react";
import Cookies from "universal-cookie";
import { getUser2 } from "../services/services";
import Swal from "sweetalert2";
import { useNavigate } from "react-router-dom";

const SalaCine = ({ from }) => {
  const navigate = useNavigate();
  const numAsientos = 40;
  const [asientosSeleccionados, setAsientosSeleccionados] = useState([]);
  const toggleAsiento = (asiento) => {
    if (asientosSeleccionados.includes(asiento)) {
      setAsientosSeleccionados(
        asientosSeleccionados.filter((a) => a !== asiento)
      );
    } else {
      setAsientosSeleccionados([...asientosSeleccionados, asiento]);
    }
  };

  const handlePayClick = () => {
    const cookies = new Cookies();
    const para = cookies.get("usuario");
    console.log("ojo",asientosSeleccionados)
    if (asientosSeleccionados.length === 0) {
      Swal.fire({
        title: "¡Hola!",
        text: "Selecciona los asientos",
        icon: "error",
        confirmButtonText: "¡Entendido!",
      });
    } else {
      const body = "Estos son los asientos que compraste " + asientosSeleccionados + " de la película " + from.titulo;
      console.log(para, body);
      
      getUser2(para, body)
        .then((response) => {
          console.log("Respuesta del servidor:", response);
          Swal.fire({
            title: "¡Hola!",
            text: response.data,
            icon: "success",
            confirmButtonText: "¡Entendido!",
          });
          navigate("/");
        })
        .catch((error) => {
          console.error("Error del servidor:", error.response.data);
          Swal.fire({
            title: "¡Hola!",
            text: error.response.data,
            icon: "error",
            confirmButtonText: "¡Entendido!",
          });
        });
    }
  };

  return (
    <div>
      <div className="container mt-5">
        <h2 className="text-center mb-4">Sala de Cine - ({from.titulo})</h2>
        <div className="d-flex flex-wrap justify-content-center">
          {Array.from({ length: numAsientos }, (_, index) => (
            <button
              key={index}
              className={`btn btn-outline-primary m-2 ${
                asientosSeleccionados.includes(index + 1) ? "btn-primary" : ""
              }`}
              onClick={() => toggleAsiento(index + 1)}
            >
              {index + 1}
            </button>
          ))}
        </div>
        <p className="mt-3 text-center">
          Asientos seleccionados: {asientosSeleccionados.join(", ")}
        </p>
      </div>
      <button
        onClick={() => handlePayClick()}
        className="btn btn-success m-1 btn-sm"
      >
        Continuar Pago
      </button>
    </div>
  );
};

export default SalaCine;
