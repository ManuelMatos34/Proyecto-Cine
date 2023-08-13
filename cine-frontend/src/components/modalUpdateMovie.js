import React, { useState, useEffect } from "react";
import { putMovie } from "../services/services";
import Swal from "sweetalert2";

const ModalUpdateMovie = ({ movie }) => {
  const [formData, setFormData] = useState({
    IdPelicula: "",
    Titulo: "",
    Genero: "",
    Duracion: "",
    Sinopsis: "",
    Poster: "",
    Idioma: "",
    Fecha: "",
    Trailer: "",
  });

  useEffect(() => {
    if (movie) {
      setFormData({
        IdPelicula: movie.idPelicula || "",
        Titulo: movie.titulo || "",
        Genero: movie.genero || "",
        Duracion: movie.duracion || "",
        Sinopsis: movie.sinopsis || "",
        Poster: movie.poster || "",
        Idioma: movie.idioma || "",
        Fecha: movie.fecha || "",
        Trailer: movie.trailer || "",
        Status: movie.status || "",
      });
    }
  }, [movie]);

  const handleChange = (e) => {
    const { id, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [id]: value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    putMovie(formData)
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
  };

  return (
    <div>
      <div
        className="modal fade"
        id="updateMovieModal"
        tabIndex="-1"
        aria-labelledby="uModalLabel"
        aria-hidden="true"
      >
        <div className="modal-dialog">
          <div className="modal-content">
            <div className="modal-header d-flex justify-content-center align-items-center">
              <h1>Editar Película</h1>
            </div>
            <div className="modal-body">
              <div className="container">
                <form onSubmit={handleSubmit}>
                  <input
                    readOnly
                    hidden
                    type="text"
                    id="IdPelicula"
                    value={formData.IdPelicula}
                  />
                  <div className="row mb-3">
                    <div className="col-md-8">
                      <label htmlFor="Titulo" className="form-label">
                        Título:
                      </label>
                      <input
                        type="text"
                        className="form-control"
                        id="Titulo"
                        value={formData.Titulo}
                        onChange={(e) => handleChange(e)}
                      />
                    </div>
                    <div className="col-md-4">
                      <label htmlFor="Genero" className="form-label">
                        Género:
                      </label>
                      <select
                        className="form-select"
                        id="Genero"
                        onChange={(e) => handleChange(e)}
                      >
                        <option value={formData.Genero}>
                          {formData.Genero}
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
                  <div className="row mb-3">
                    <div className="col-md-6">
                      <label htmlFor="Duracion" className="form-label">
                        Duración (minutos):
                      </label>
                      <input
                        type="text"
                        className="form-control"
                        id="Duracion"
                        value={formData.Duracion}
                        onChange={(e) => handleChange(e)}
                      />
                    </div>
                    <div className="col-md-6">
                      <label htmlFor="Idioma" className="form-label">
                        Idioma:
                      </label>
                      <select
                        className="form-select"
                        id="Idioma"
                        onChange={(e) => handleChange(e)}
                      >
                        <option value={formData.Idioma}>
                          {formData.Idioma}
                        </option>
                        <option value="Esp">Español</option>
                        <option value="Eng">Inglés</option>
                      </select>
                    </div>
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
                      onChange={(e) => handleChange(e)}
                    ></textarea>
                  </div>
                  <div className="mb-3">
                    <label htmlFor="Poster" className="form-label">
                      Poster (link):
                    </label>
                    <input
                      type="text"
                      className="form-control"
                      id="Poster"
                      value={formData.Poster}
                      onChange={(e) => handleChange(e)}
                    />
                  </div>
                  <div className="row mb-3">
                    <div className="col-md-6">
                      <label htmlFor="Fecha" className="form-label">
                        Fecha:
                      </label>
                      <input
                        type="datetime-local"
                        className="form-control"
                        id="Fecha"
                        value={formData.Fecha}
                        onChange={(e) => handleChange(e)}
                      />
                    </div>
                  </div>
                  <div className="mb-3">
                    <label htmlFor="Trailer" className="form-label">
                      Trailer:
                    </label>
                    <input
                      type="text"
                      className="form-control"
                      id="Trailer"
                      value={formData.Trailer}
                      onChange={(e) => handleChange(e)}
                    />
                  </div>
                  <button type="submit" className="btn btn-success">
                    Guardar
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

export default ModalUpdateMovie;
