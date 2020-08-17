import axios from "axios";
import CookieService from "../services/CookieService";


const https = (path,baseURL) => {

    // SOLO DE DEMOSTRACION
    // Cambiar la URL a la de net core
    var BASE_URL =  baseURL ?? "https://localhost:5001/api"

    var created = axios.create({
        baseURL:  BASE_URL + path,
        headers: {
            "Content-type": "application/json"
        }
    });

    created.interceptors.request.use( config => {
        var token = CookieService.getCookies()["token"];
        config.headers['Authorization'] = 'Bearer ' + token;;
        return config
    },
    error => Promise.reject(error));

    return created;
}

const builder = (path,baseURL) => {
    return {
        https: https(path,baseURL)
    }
};

export default builder;