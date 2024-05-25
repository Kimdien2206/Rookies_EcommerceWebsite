import { http } from "."
import { LoginRequest } from "../types/Auth"


export const login = (loginRequest: LoginRequest) => {
    return http.post("/Auth/Login", loginRequest);
}

export const getToken = (loginRequest: LoginRequest) => {
    return http.post("/Auth/GetToken", loginRequest);
}