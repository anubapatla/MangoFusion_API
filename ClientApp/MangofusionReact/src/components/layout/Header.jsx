import {ROUTES} from '../../utility/constants';
import{NavLink} from 'react-router-dom';
function Header(){
    return(
        <nav className="navbar navbar-expand-lg border-bottom shadow-sm">
            <div className="container py-2">
                <NavLink to={ROUTES.HOME} className="navbar-brand d-flex align-items-center gap-2">
                <i className="bi bi-fire text-primary fs-4"></i>
                <span className="fw-bold">MangoFusion</span>
                </NavLink>
                <button className="navbar-toggler" type="button" 
                data-bs-toggle="collapse" data-bs-target="#mainNav"
                 aria-controls="mainNav" aria-expanded="false" 
                 aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="mainNav">
                    <ul className="navbar-nav me-auto mb-2 mb-lg-0 ">
                        <li className="nav-item">
                            <NavLink to={ROUTES.ORDER_MANAGEMENT} className="nav-link">My orders</NavLink>
                        </li>
                    </ul>
                    <ul className="navbar-nav ms-auto align-items-lg-center gap-lg-1">
                       {/*  theme toggle visible for all users*/ }
                       <li className="nav-item me-lg-2">
                        <NavLink to={ROUTES.CART} className={`nav-link position-relative d-flex align-items-center justify-content-center bg-primary-subtle rounded-circle`}
                        style={{width:"44px", height:"44px"}}> 
                        <i className="bi bi-cart fs-4"></i>
                        <span className="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger text-white start-110"
                            style={{fontSize:"0.7rem"}}>
                            10
                         </span>
                            </NavLink></li>
                            <li className="nav-item dropdown">
                                <button className="nav-link dropdown-toggle btn btn-link d-flex align-items-center gap-2"
                                data-bs-toggle="dropdown" aria-expanded="false">
                                <i className="bi bi-person-circle fs-5 text-primary"></i>
                                <span className="text-truncate"
                                 style={{maxWidth:"120px"}}>
                                    Hello
                                </span>
                                </button>
                                <ul className="dropdown-menu dropdown-menu-end shadow border rounded-3 p-2 small"
                                style={{
                                    minwidth:"200px",
                                    "--bs-dropdown-link-active-bg":"#e7f1ff",
                                    "--bs-dropdown-link-active-color":"#0d6efd",
                                    "--bs-dropdown-link-hover-bg":"yellow",
                                }}> 
                                <li>
                                    <NavLink to={ROUTES.ORDER_MANAGEMENT} 
                                    className="dropdown-item d-flex align-items-center rounded-3 p-2 small">
                                  <li className="bi bi-speedometer fs-5 text-primary"></li>
                                  <span>Order management</span>
                                  </NavLink>
                                  </li>
                                  <li>
                                    <NavLink to={ROUTES.MENU_MANAGEMENT}
                                    className="dropdown-item d-flex align-items-center gap-2 rounded-2">
                                  <li className="bi bi-person fs-5 text-primary"></li>
                                  <span>menu management</span> 
                                  </NavLink></li>
                                  <li>
                                    <hr className="dropdown-divider my-2"></hr>
                                    </li>
                                    <li>
                                    <button className="dropdown-item d-flex align-items-center gap-2  text-danger rounded-2">
                                        <i className="bi bi-box-arrow-right "></i> 
                                        <span>Logout</span>
                                    </button>
                                    </li>
                                    </ul>
                                    </li> 
                                    <li className="nav-item "> 
                                        <NavLink to={ROUTES.REGISTER} className="nav-link">Register</NavLink> 
                                         </li>
                                         <li className="nav-item "> 
                                         <NavLink to={ROUTES.LOGIN} className="nav-link">Login</NavLink> 
                                         </li>
                                        </ul>   
                </div>
            </div>
        </nav>);
    
}
export default Header;