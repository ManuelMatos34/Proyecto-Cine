import React, { useState } from "react";
import LoginForm from "./loginForm";
import RegisterForm from "./registerForm";

const ModalEntrar = () => {
  const [showLoginForm, setShowLoginForm] = useState(true);

  const handleShowLogin = () => {
    setShowLoginForm(true);
  };

  const handleShowRegister = () => {
    setShowLoginForm(false);
  };

  return (
    <div>
      <div
        className="modal fade"
        id="exampleModal"
        tabIndex="-1"
        aria-labelledby="exampleModalLabel"
        aria-hidden="true"
      >
        <div className="modal-dialog">
          <div className="modal-content">
            <div className="modal-header d-flex justify-content-center align-items-center">
              <div className="d-flex justify-content-center gap-2">
                <button
                  type="button"
                  className={`btn btn-danger btn-lg border-0 ${showLoginForm ? 'active' : ''}`}
                  onClick={handleShowLogin}
                >
                  Iniciar Sesión
                </button>
                <button
                  type="button"
                  className={`btn btn-danger btn-lg border-0 ${!showLoginForm ? 'active' : ''}`}
                  onClick={handleShowRegister}
                >
                  Registrarse
                </button>
              </div>
            </div>
            <div className="modal-body">
              {showLoginForm ? <LoginForm /> : <RegisterForm />}
            </div>
            <div className="modal-footer">
              <button
                type="button"
                className="btn btn-secondary"
                data-bs-dismiss="modal"
              >
                Cerrar
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ModalEntrar;