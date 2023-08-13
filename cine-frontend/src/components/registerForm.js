import React, { useState } from "react";
import { postUser } from "../services/services";
import Swal from "sweetalert2";

const RegisterForm = () => {
  const initialState = {
    IdCliente: 0,
    Usuario: "",
    Nombre: "",
    Apellido: "",
    Password: "",
    CorreoElectronico: "",
  };

  const [formData, setFormData] = useState(initialState);

  const handleInputChange = (e) => {
    const { id, value } = e.target;
    setFormData((prevData) => ({ ...prevData, [id]: value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    postUser(formData)
      .then((response) => {
        console.log("Respuesta del servidor:", response);
        Swal.fire({
          title: "¡Hola!",
          text: response.data,
          icon: "success",
          confirmButtonText: "¡Entendido!",
        });
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

    resetForm();
  };

  const resetForm = () => {
    setFormData(initialState);
  };

  return (
    <div className="container">
      <form onSubmit={handleSubmit} className="row g-3">
        <div className="col-md-6">
          <label htmlFor="Usuario" className="form-label">
            Usuario:
          </label>
          <input
            type="text"
            className="form-control"
            id="Usuario"
            value={formData.Usuario}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className="col-md-6">
          <label htmlFor="Nombre" className="form-label">
            Nombre:
          </label>
          <input
            type="text"
            className="form-control"
            id="Nombre"
            value={formData.Nombre}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className="col-md-6">
          <label htmlFor="CorreoElectronico" className="form-label">
            Email:
          </label>
          <input
            type="text"
            className="form-control"
            id="CorreoElectronico"
            value={formData.CorreoElectronico}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className="col-md-6">
          <label htmlFor="Apellido" className="form-label">
            Apellido:
          </label>
          <input
            type="text"
            className="form-control"
            id="Apellido"
            value={formData.Apellido}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className="col-md-12">
          <label htmlFor="Password" className="form-label">
            Password:
          </label>
          <input
            type="password"
            className="form-control"
            id="Password"
            value={formData.Password}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className="col-md-12">
          <button type="submit" className="btn btn-success">
            Registrarme
          </button>
        </div>
      </form>
    </div>
  );
};

export default RegisterForm;
