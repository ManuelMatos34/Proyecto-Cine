import React from "react";

const CheckoutForm = () => {
  return (
    <div className="row">
      <div className="col-75">
        <div className="container">
          <form>
            <div className="row">
              <div className="col-md-6">
                <h3>Dirección de Facturación</h3>
                <label htmlFor="fname">
                  <i className="fa fa-user"></i> Nombre Completo
                </label>
                <input
                  type="text"
                  className="form-control"
                  id="fname"
                  name="firstname"
                  placeholder="Juan M. Pérez"
                />
                <label htmlFor="email">
                  <i className="fa fa-envelope"></i> Correo Electrónico
                </label>
                <input
                  type="text"
                  className="form-control"
                  id="email"
                  name="email"
                  placeholder="juan@example.com"
                />
                <label htmlFor="adr">
                  <i className="fa fa-address-card-o"></i> Dirección
                </label>
                <input
                  type="text"
                  className="form-control"
                  id="adr"
                  name="address"
                  placeholder="Calle 542, Colonia 15"
                />
                <label htmlFor="city">
                  <i className="fa fa-institution"></i> Ciudad
                </label>
                <input
                  type="text"
                  className="form-control"
                  id="city"
                  name="city"
                  placeholder="Ciudad de México"
                />

                <div className="row">
                  <div className="col-md-6">
                    <label htmlFor="state">Estado</label>
                    <input
                      type="text"
                      className="form-control"
                      id="state"
                      name="state"
                      placeholder="CDMX"
                    />
                  </div>
                  <div className="col-md-6">
                    <label htmlFor="zip">Código Postal</label>
                    <input
                      type="text"
                      className="form-control"
                      id="zip"
                      name="zip"
                      placeholder="10001"
                    />
                  </div>
                </div>
              </div>

              <div className="col-md-6">
                <h3>Pago</h3>
                <label htmlFor="fname">Tarjetas Aceptadas</label>
                <label htmlFor="cname">Nombre en la Tarjeta</label>
                <input
                  type="text"
                  className="form-control"
                  id="cname"
                  name="cardname"
                  placeholder="Juan Más Pérez"
                />
                <label htmlFor="ccnum">Número de Tarjeta de Crédito</label>
                <input
                  type="text"
                  className="form-control"
                  id="ccnum"
                  name="cardnumber"
                  placeholder="1111-2222-3333-4444"
                />
                <label htmlFor="expmonth">Mes de Vencimiento</label>
                <input
                  type="text"
                  className="form-control"
                  id="expmonth"
                  name="expmonth"
                  placeholder="Septiembre"
                />

                <div className="row">
                  <div className="col-md-6">
                    <label htmlFor="expyear">Año de Vencimiento</label>
                    <input
                      type="text"
                      className="form-control"
                      id="expyear"
                      name="expyear"
                      placeholder="2023"
                    />
                  </div>
                  <div className="col-md-6">
                    <label htmlFor="cvv">CVV</label>
                    <input
                      type="text"
                      className="form-control"
                      id="cvv"
                      name="cvv"
                      placeholder="352"
                    />
                  </div>
                </div>
              </div>
            </div>
            {/* <div className="m-3 p-3">
              <input
                type="submit"
                value="Continuar al pago"
                className="btn btn-success"
              />
            </div> */}
          </form>
        </div>
      </div>
    </div>
  );
};

export default CheckoutForm;
