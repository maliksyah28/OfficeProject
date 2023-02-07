import axios from "axios";

const axiosInstance = axios.create({ baseURL: "https://localhost:7273/" });

export default axiosInstance;