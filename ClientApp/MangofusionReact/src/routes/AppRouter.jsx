import {  Routes, Route } from "react-router-dom";
import Home from "../pages/Home";
import Login from "../pages/auth/Login";
import Register from "../pages/auth/Register";
import Cart from "../pages/cart/Cart";
import Checkout from "../pages/cart/Checkout";
import OrderConfirmation from "../pages/order/OrderConfirmation";
import MenuitemManagement from "../pages/menu/MenuitemManagement";
import OrderManagement from "../pages/order/OrderManagement";
import { ROUTES } from "../utility/constants";
const Approutes =()=>{
    return (
    <Routes>
        <Route path={ROUTES.HOME} element={<Home/>}/>
        <Route path={ROUTES.LOGIN} element={<Login/>}/> 
        <Route path={ROUTES.REGISTER} element={<Register/>}/>
        <Route path={ROUTES.CART} element={<Cart/>}/>
        <Route path={ROUTES.CHECKOUT} element={<Checkout/>}/>
        <Route path={ROUTES.ORDER_CONFIRMATION} element={<OrderConfirmation/>}/>
        <Route path={ROUTES.MENU_MANAGEMENT} element={<MenuitemManagement/>}/>
        <Route path={ROUTES.ORDER_MANAGEMENT} element={<OrderManagement/>}/>
    </Routes>
    );

}
export default Approutes;