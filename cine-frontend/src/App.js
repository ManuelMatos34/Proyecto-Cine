import React from "react";
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Home from './pages/home/home';
import Client from "./pages/client/client";
import './assets/styles/styles.css'
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/Client" element={<Client />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;