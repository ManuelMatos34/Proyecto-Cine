import React, { useEffect, useState } from "react";
import { deleteMovie } from "../services/services";

const DeleteMovieModal = ({ movie }) => {
  const [movieId, setMovieId] = useState(0);
  useEffect(() => {
    if (movie) {
      setMovieId(movie.idPelicula);
    }
  }, [movie]);

  const handleDeleteClick = () => {
    deleteMovie(movieId)
      .then((response) => {
        console.log("Respuesta del servidor:", response);
        window.location.reload();
      })
      .catch((error) => {
        console.error("Error del servidor:", error.response.data);
        alert(error.response.data);
      });
  };

  return (
    <div>
      <div
        className="modal fade"
        id="deleteMovieModal"
        tabIndex="-1"
        aria-labelledby="exampleModalLabel"
        aria-hidden="true"
      >
        <div className="modal-dialog">
          <div className="modal-content">
            <div className="modal-header d-flex justify-content-center align-items-center">
              <h1>Eliminar Película</h1>
            </div>
            <div className="modal-body">
              <div className="container">
                {movie && (
                  <p>
                    Seguro que quieres eliminar la película: {movie.titulo}?
                  </p>
                )}
              </div>
            </div>
            <div className="modal-footer">
              <button onClick={handleDeleteClick} className="btn btn-danger">
                Eliminar
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default DeleteMovieModal;
