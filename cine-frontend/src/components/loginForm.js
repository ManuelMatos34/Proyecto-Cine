import React, { useState } from "react";
import { getUser } from "../services/services";
import Cookies from "universal-cookie";
import { useNavigate } from "react-router-dom";
import Swal from "sweetalert2";

const LoginForm = () => {
  const initialState = {
    Usuario: "",
    Password: "",
  };

  const [formData, setFormData] = useState(initialState);
  const cookies = new Cookies();
  const navigate = useNavigate();
  const handleInputChange = (e) => {
    const { id, value } = e.target;
    setFormData((prevData) => ({ ...prevData, [id]: value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    getUser(formData.Usuario, formData.Password)
      .then((response) => {
        const client = response.data
        console.log("Respuesta del servidor:", client);
        cookies.set('id', client.id, {path: "/"});
        cookies.set('nombre', client.nombre, {path: "/"});
        cookies.set('apellido', client.apellido, {path: "/"});
        cookies.set('usuario', client.usuario, {path: "/"});
        cookies.set('password', client.password, {path: "/"});
        cookies.set('email', client.email, {path: "/"});
        cookies.set('rol', client.rol, {path: "/"});
        console.log("Rol actual:", cookies.get("rol"))
        navigate("/");
        window.location.reload();
      })
      .catch((error) => {
        console.error("Error al obtener los datos del servidor:", error.response.data);
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
      <form onSubmit={handleSubmit}>
      <div className="mb-3">
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
        <div className="mb-3">
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
        <button type="submit" className="btn btn-success">
          Entrar
        </button>
      </form>
    </div>
  );
};

export default LoginForm;
