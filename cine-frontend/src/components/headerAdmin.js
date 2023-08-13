/* eslint-disable jsx-a11y/anchor-is-valid */
import React from "react";

const HeaderAdmin = ({salir}) => {
  return (
    <div>
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
        <a className="navbar-brand m-1" href="#">
          <img
            src="https://cdn0.iconfinder.com/data/icons/social-media-2071/100/smartphone-15-512.png"
            width="30"
            height="30"
            className="d-inline-block align-top"
            alt=""
          />
          Movie Time
        </a>
        <div
          className="collapse navbar-collapse justify-content-end"
          id="navbarSupportedContent"
        >
          <ul className="navbar-nav">
            <li className="nav-item m-1">
              <button
                type="button"
                className="btn btn-danger"
                onClick={() => salir()}
              >
                Salir
              </button>
            </li>
          </ul>
        </div>
      </nav>
    </div>
  );
};

export default HeaderAdmin;
