import { configureStore } from "@reduxjs/toolkit";
import { baseApi } from "../api/baseApi";

export const store = configureStore({
    reducer:{
        [baseApi.reducer]:baseApi.reducer
    }
    ,
    middleware:(getDefaultMiddleware)=>
        getDefaultMiddleware().contact(baseApi.middleware)
});
export default store;