import React, { useState, useEffect } from "react";
import Header from "../../components/header";
import HeaderAdmin from "../../components/headerAdmin";
import HeaderClient from "../../components/headerClient";
import Filter from "../../components/filter";
import MovieCard from "../../components/movieCard";
import { getMovies } from "../../services/services.js";
import Cookies from "universal-cookie";
import { useNavigate } from "react-router-dom";

const Home = () => {
  const cookies = new Cookies();
  const newUser = cookies.get("usuario");
  const [categoria, setCategoria] = useState("");
  const [buscador, setBuscador] = useState("");
  const [rol, setRol] = useState("");
  const [movies, setMovies] = useState([]);
  const navigate = useNavigate();

  const salir = () => {
    const cookies = new Cookies();
    cookies.remove("id", { path: "/" });
    cookies.remove("nombre", { path: "/" });
    cookies.remove("apellido", { path: "/" });
    cookies.remove("usuario", { path: "/" });
    cookies.remove("password", { path: "/" });
    cookies.remove("email", { path: "/" });
    cookies.remove("rol", { path: "/" });
    console.log("Rol actual:", cookies.get("rol"));
    navigate("/");
    window.location.reload();
  };

  useEffect(() => {
    const cookies = new Cookies();
    const newRol = cookies.get("rol");
    setRol(newRol);
  }, []);

  useEffect(() => {
    const fetchMovies = () => {
      getMovies()
        .then((response) => {
          let filteredMovies = response.data;
          if (buscador) {
            filteredMovies = filteredMovies.filter((movie) =>
              movie.titulo.toLowerCase().includes(buscador.toLowerCase())
            );
          }
          if (categoria) {
            filteredMovies = filteredMovies.filter(
              (movie) => movie.genero.toLowerCase() === categoria.toLowerCase()
            );
          }
          if (categoria === "Todo") {
            window.location.reload();
          }

          setMovies(filteredMovies);
        })
        .catch((error) => {
          console.error(error);
        });
    };

    fetchMovies();
  }, [categoria, buscador]);
  return (
    <div>
      <div>
        <div>
          {rol === "admin" ? (
            <HeaderAdmin salir={salir} />
          ) : rol === "cliente" ? (
            <HeaderClient salir={salir} />
          ) : (
            <Header />
          )}
        </div>
        {newUser !== undefined ? (
          <div className="text-end m-3">
            <p>
              <b>Bienvenido.</b> {newUser}
            </p>
          </div>
        ) : null}
      </div>
      <div className="m-4">
        <Filter
          setCategoria={setCategoria}
          buscador={buscador}
          setBuscador={setBuscador}
        />
      </div>
      <div className="m-4 p-4">
        <MovieCard movies={movies} />
      </div>
    </div>
  );
};

export default Home;
