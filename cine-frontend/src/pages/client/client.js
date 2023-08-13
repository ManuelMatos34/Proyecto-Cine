import React from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import SalaCine from "../../components/salaCine";
import { useLocation } from "react-router-dom";

const Client = () => {
  const location = useLocation();
  const { from } = location.state;
  return (
    <div className="m-5 p-5">
      <div className="container">
        <div>

            <SalaCine from={from} />

        </div>
      </div>
    </div>
  );
};

export default Client;
