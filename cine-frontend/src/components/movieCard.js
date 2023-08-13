import React, { useState } from "react";
import Cookies from "universal-cookie";
import ModalUpdateMovie from "./modalUpdateMovie";
import ModalDeleteMovie from "./deleteMovieModal";
import { Link } from "react-router-dom";

const MovieCard = ({ movies }) => {
  const cookies = new Cookies();
  const actualRol = cookies.get("rol");
  const [selectedMovie, setSelectedMovie] = useState(null);
  const handleEditClick = (movie) => {
    setSelectedMovie(movie);
  };

  function formatTime(dateTime) {
    const date = new Date(dateTime);
    const hours = date.getHours();
    const minutes = date.getMinutes();
    const amPm = hours >= 12 ? "PM" : "AM";
    const formattedHours = hours % 12 || 12;
    const formattedMinutes = minutes < 10 ? `0${minutes}` : minutes;
    return `${formattedHours}:${formattedMinutes} ${amPm}`;
  }

  return (
    <div className="body">
      <ModalUpdateMovie movie={selectedMovie} />
      <ModalDeleteMovie movie={selectedMovie} />
      <div className="wrapper">
        {movies &&
          movies.map((movie) => (
            <div key={movie.idPelicula} className="card">
              <div className="poster">
                <img src={movie.poster} alt={movie.titulo} />
              </div>
              <div className="details">
                <h1>{movie.titulo}</h1>
                <h2>
                  {movie.duracion}min • {formatTime(movie.fecha)}
                </h2>
                <div className="tags">
                  <span className="tag">{movie.genero}</span>
                </div>
                <p className="desc">{movie.sinopsis}</p>
                <div className="d-flex align-items-center">
                  {actualRol === "admin" ? (
                    <div>
                      <button
                        data-bs-toggle="modal"
                        data-bs-target="#updateMovieModal"
                        className="btn btn-warning m-1 btn-sm"
                        onClick={() => handleEditClick(movie)}
                      >
                        Editar
                      </button>
                      <button
                        data-bs-toggle="modal"
                        data-bs-target="#deleteMovieModal"
                        className="btn btn-danger m-1 btn-sm"
                        onClick={() => handleEditClick(movie)}
                      >
                        Eliminar
                      </button>
                      <a
                        className="btn btn-success m-1 btn-sm"
                        href={movie.trailer}
                        target="_blank"
                        rel="noopener noreferrer"
                      >
                        Trailer
                      </a>
                    </div>
                  ) : actualRol === "cliente" ? (
                    <div>
                      <Link
                        to="/Client"
                        state={{ from: movie }}
                        className="btn btn-success m-1 btn-sm"
                      >
                        Comprar
                      </Link>
                      <a
                        className="btn btn-success m-1 btn-sm"
                        href={movie.trailer}
                        target="_blank"
                        rel="noopener noreferrer"
                      >
                        Trailer
                      </a>
                    </div>
                  ) : (
                    <div>
                      <a
                        className="btn btn-success m-1 btn-sm"
                        href={movie.trailer}
                        target="_blank"
                        rel="noopener noreferrer"
                      >
                        Trailer
                      </a>
                    </div>
                  )}
                </div>
              </div>
            </div>
          ))}
      </div>
    </div>
  );
};

export default MovieCard;
