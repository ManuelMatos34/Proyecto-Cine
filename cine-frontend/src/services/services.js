import axios from "axios";

export const getMovies = () => {
  return axios.get("https://localhost:7041/api/Peliculas/GetMovies"
  );
};

export const AddMovie = (movie) => {
  return axios.post("https://localhost:7041/api/Peliculas/AddMovies", movie);
};

export const putMovie = (movie) => {
  return axios.put("https://localhost:7041/api/Peliculas/PutMovie", movie);
};

export const deleteMovie = (Id) => {
  return axios.put(`https://localhost:7041/api/Peliculas/DeleteMovie/${Id}`);
};

export const postUser = (cliente) => {
  return axios.post("https://localhost:7041/api/Clientes/PostUser", cliente);
};

export const emailSend = (user, pass) => {
  return axios.post("https://localhost:7041/api/Clientes/EmailSend", { user, pass });
};

export const getUser = (user, pass) => {
  return axios.get("https://localhost:7041/api/Clientes/GetUser", {
    params: {
      user: user,
      pass: pass,
    },
  });
};

export const getUser2 = (user, pass) => {
  return axios.get("https://localhost:7041/api/Clientes/GetUser2", {
    params: {
      user: user,
      pass: pass,
    },
  });
};
