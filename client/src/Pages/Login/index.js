import { login } from "../../auth/authSlice/authSlice";
import axiosInstance from "../../Services/axios";
import { useDispatch, useSelector } from "react-redux";
import { useState } from "react";
import './styles.css';
import {
    Flex,
} from "@chakra-ui/react";
import { Navigate, useNavigate, Link } from "react-router-dom";

export default function Login() {
    const navigate = useNavigate()
    const [email,setEmail] = useState("")
    const [password,setPassword] = useState("")
    const [roleId,setRoleId]= useState("")

    const dispatch = useDispatch()
    const emailHandleChange = (event) => {
        setEmail(event.target.value)
    }
    const passHandleChange = (event) => {
        setPassword(event.target.value);
      };

      const loginClick = async () => {
        try {
            const body = {
                email: email,
                password : password
            }
            const res= await axiosInstance.post("api/Login",body)
            console.log(res);
            const user = res.data.data
            const action = login(user)
            dispatch(action)
            const userInfo = {
                NIK : user.nik,
                roleId : user.roleId,
                token : user.token
            }
            const strUser = JSON.stringify(userInfo)
            localStorage.setItem("userInfo",strUser)
            navigate("/")
        } catch (error) {
            console.log(error);
        }
      }
      const userRole = useSelector((state) => state.auth.Token);
  return (
    <div class="login-card">
      <h2>Login</h2>
      <h3>Enter your credentials</h3>
      <form class="login-form">
        <input type="text" placeholder="email" value={email} onChange={emailHandleChange} />
        <input type="password" placeholder="Password"  value={password} onChange={passHandleChange} />
        <a href="https://website.com">Forgot your password?</a>
        <button type="button" onClick={loginClick}>LOGIN</button>
      </form>
    </div>
  );
}
