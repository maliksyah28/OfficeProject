import logo from "./logo.svg";
import "./App.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { useDispatch } from "react-redux";
import { login } from "./auth/authSlice/authSlice";
import { useEffect, useState } from "react";

//pages
import Login from "./Pages/Login";
import Home from "./Pages/Home";

function App() {
  const [isLocalStorageChecked, setisLocalStorageChecked] = useState(false);
  const dispatch = useDispatch();
  useEffect(() => {
    // string
    const userLocalStorage = localStorage.getItem("userInfo");

    // ada ga isinya ?
    if (userLocalStorage) {
      // ubah string menjadi object
      const user = JSON.parse(userLocalStorage);
      // objectnya dimasukkan ke action creator login
      // menghasilkan action --> { type: "auth/login", payload : user }
      const action = login(user);
      // kirim ke reducer
      dispatch(action);
    }

    setisLocalStorageChecked(true);
  }, []);
  if (isLocalStorageChecked) {
    return (
      <BrowserRouter>
        <Routes>
        <Route path="/" element={<Home/>} />
          <Route path="/login" element={<Login />} />
        </Routes>
      </BrowserRouter>
    );
  }
  
    return <h1 style={{ textAlign: "center" }}>Checking Local Storage</h1>;
  
}

export default App;
