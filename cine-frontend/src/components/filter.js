import React from "react";
import Cookies from "universal-cookie";
import ModalAddMovie from "./modalAddMovie";

const Filter = ({ setCategoria, buscador, setBuscador }) => {
  const cookies = new Cookies();
  const actualRol = cookies.get("rol");
  return (
    <div className="d-flex justify-content-between align-items-center">
      <ModalAddMovie />
      <form className="flex-grow-1">
        <input
          type="text"
          id="search"
          placeholder="Buscar"
          className="search m-1"
          value={buscador}
          onChange={(e) => setBuscador(e.target.value)}
        />
        <div>
          <input
            type="button"
            name="aventura"
            id="aventura-button"
            value="Aventura"
            onClick={() => setCategoria("Aventura")}
            className="btn btn-danger m-1 btn-sm"
          />
          <input
            type="button"
            name="comedia"
            id="comedia-button"
            value="Comedia"
            onClick={() => setCategoria("Comedia")}
            className="btn btn-danger m-1 btn-sm"
          />
          <input
            type="button"
            name="animación"
            id="animación-button"
            value="Animación"
            onClick={() => setCategoria("Animación")}
            className="btn btn-danger m-1 btn-sm"
          />
          <input
            type="button"
            name="ciencia-ficción"
            id="ciencia-ficción-button"
            value="Ciencia-Ficción"
            onClick={() => setCategoria("Ciencia-Ficción")}
            className="btn btn-danger m-1 btn-sm"
          />
          <input
            type="button"
            name="acción"
            id="acción-button"
            value="Acción"
            onClick={() => setCategoria("Acción")}
            className="btn btn-danger m-1 btn-sm"
          />
          <input
            type="button"
            name="drama"
            id="drama-button"
            value="Drama"
            onClick={() => setCategoria("Drama")}
            className="btn btn-danger m-1 btn-sm"
          />
          <input
            type="button"
            name="todo"
            id="todo-button"
            value="Todo"
            onClick={() => setCategoria("Todo")}
            className="btn btn-secondary m-1 btn-sm"
          />
        </div>
      </form>
      {actualRol === "admin" ? (
        <div className="ml-2">
          <button
            data-bs-toggle="modal"
            data-bs-target="#AddMovieModal"
            className="btn btn-success"
          >
            Agregar
          </button>
        </div>
      ) : null}
    </div>
  );
};

export default Filter;
