import React, { useState } from "react";
import { AddMovie } from "../services/services";
import Swal from "sweetalert2";

const ModalAddMovie = () => {
  const movieModel = {
    Titulo: "",
    Genero: "",
    Duracion: "",
    Sinopsis: "",
    Poster: "",
    Idioma: "",
    Fecha: "",
    Trailer: "",
  };

  const [formData, setFormData] = useState(movieModel);

  const handleInputChange = (e) => {
    const { id, value } = e.target;
    setFormData((prevData) => ({ ...prevData, [id]: value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    AddMovie(formData)
      .then((response) => {
        console.log("Respuesta del servidor:", response);
        window.location.reload();
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
    setFormData(movieModel);
  };
  return (
    <div>
      <div
        className="modal fade"
        id="AddMovieModal"
        tabIndex="-1"
        aria-labelledby="exampleModalLabel"
        aria-hidden="true"
      >
        <div className="modal-dialog">
          <div className="modal-content">
            <div className="modal-header d-flex justify-content-center align-items-center">
              <h1>Agregar Película</h1>
            </div>
            <div className="modal-body">
              <div className="container">
                <form onSubmit={handleSubmit}>
                  <div className="row mb-3">
                    <div className="col-md-8">
                      <label htmlFor="Titulo" className="form-label">
                        Título:
                      </label>
                      <input
                        value={formData.Titulo}
                        onChange={handleInputChange}
                        type="text"
                        className="form-control"
                        id="Titulo"
                        required
                      />
                    </div>
                    <div className="col-md-4">
                      <label htmlFor="Genero" className="form-label">
                        Género:
                      </label>
                      <select
                        value={formData.Genero}
                        onChange={handleInputChange}
                        className="form-select"
                        id="Genero"
                        required
                      >
                        <option disabled value="">
                          ...
                        </option>
                        <option value="Comedia">Comedia</option>
                        <option value="Animación">Animación</option>
                        <option value="Aventura">Aventura</option>
                        <option value="Ciencia-Ficción">Ciencia-Ficción</option>
                        <option value="Acción">Acción</option>
                        <option value="Drama">Drama</option>
                      </select>
                    </div>
                  </div>
                  <div className="mb-3">
                    <label htmlFor="Duracion" className="form-label">
                      Duración (minutos):
                    </label>
                    <input
                      value={formData.Duracion}
                      onChange={handleInputChange}
                      type="text"
                      className="form-control"
                      id="Duracion"
                      required
                    />
                  </div>
                  <div className="mb-3">
                    <label htmlFor="Sinopsis" className="form-label">
                      Sinopsis:
                    </label>
                    <textarea
                      className="form-control"
                      id="Sinopsis"
                      rows="3"
                      value={formData.Sinopsis}
                      onChange={handleInputChange}
                      required
                    ></textarea>
                  </div>
                  <div className="row mb-3">
                    <div className="col-md-6">
                      <label htmlFor="Poster" className="form-label">
                        Poster (link):
                      </label>
                      <input
                        value={formData.Poster}
                        onChange={handleInputChange}
                        type="text"
                        className="form-control"
                        id="Poster"
                        required
                      />
                    </div>
                    <div className="col-md-6">
                      <label htmlFor="Idioma" className="form-label">
                        Idioma:
                      </label>
                      <select
                        value={formData.Idioma}
                        onChange={handleInputChange}
                        className="form-select"
                        id="Idioma"
                        required
                      >
                        <option disabled value="">
                          ...
                        </option>
                        <option value="Esp">Español</option>
                        <option value="Eng">Inglés</option>
                      </select>
                    </div>
                  </div>
                  <div className="mb-3">
                    <label htmlFor="Fecha" className="form-label">
                      Fecha:
                    </label>
                    <input
                      value={formData.Fecha}
                      onChange={handleInputChange}
                      type="datetime-local"
                      className="form-control"
                      id="Fecha"
                      required
                    />
                  </div>
                  <div className="mb-3">
                    <label htmlFor="Trailer" className="form-label">
                      Trailer:
                    </label>
                    <input
                      value={formData.Trailer}
                      onChange={handleInputChange}
                      type="text"
                      className="form-control"
                      id="Trailer"
                      required
                    />
                  </div>
                  <button type="submit" className="btn btn-success">
                    Agregar
                  </button>
                </form>
              </div>
            </div>
            <div className="modal-footer"></div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ModalAddMovie;
