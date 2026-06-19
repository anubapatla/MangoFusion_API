import {  Routes, Route } from "react-router-dom";
import Home from "../pages/Home";
const Approutes =()=>{
    return (
    <Routes>
        <Route path="/" element={<Home/>}/>
        {/* <Route path="/login" element={<Login/>}/> 
        <Route path="/register" element={<Register/>}/>
        <Route path="/cart" element={<Cart/>}/>
        <Route path="/checkout" element={<Checkout/>}/>
        <Route path="/order-confirmation" element={<OrderConfirmation/>}/>
        <Route path="/menu-management" element={<MenuitemManagement/>}/>
        <Route path="/order-management" element={<OrderManagement/>}/>*/}
    </Routes>
    );

}
export default Approutes;