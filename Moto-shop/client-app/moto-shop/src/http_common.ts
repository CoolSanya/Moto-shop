import axios from "axios";

export default axios.create({
    baseURL: "Server=PC;Database=moto-shop;Trusted_Connection=True;",
    headers: {
        "Content-type": "application/json"
    }
});