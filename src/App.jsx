import { useState,useContext } from 'react'
import './App.css'
import { AppContext } from "./StateMangment";
import {  Routes, Route, Router } from "react-router-dom";
import OtpPage from './Pages/OTP/OTPPage';
import LoginPage from './Pages/LoginPage/LoginPage';
import HomePage from './Pages/HomePage/HomePage';
import RegisterPage from './Pages/RegisterPage/RegisterPage'
import ResetPasswordPage from './Pages/ResetPasswordPage/ResetPasswordPage';
import ForgotPasswordPage from './Pages/ForgetPasswordPage/ForgetPasswordPage';
import PathEditPage from './Pages/PathEditPage/PathEditPage';
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
function App() {
      const { user, token } = useContext(AppContext);

// if(user != null &&user.role.toLowerCase()==='user'&&token){
//   return (
//     <>


//     </>
//   )
// }


//   else if(user != null &&user.role.toLowerCase()==='admin'&&token){
//  return (
//     <>
 



//     </>
//   )
//   }

  // else{
 return (
   <>
    <Routes>
 <Route path="/Login" element={<><LoginPage/></>}/>

 <Route path="/Otp" element={<>  <OtpPage/>  </>}/>


 <Route path="/newRegister" element={<>  <RegisterPage/>  </>}/>
  <Route path="/newRegister/:userId" element={<>  <RegisterPage/>  </>}/>

 <Route path="/ForgetPassword" element={<>  <ForgotPasswordPage/>  </>}/>

 <Route path="/ResetPassword" element={<>  <ResetPasswordPage/>  </>}/>

  <Route path="/Editpath/*" element={<><PathEditPage/></>} />

   <Route path="/Addpath/*" element={<><PathEditPage/></>} />

  <Route path="/*" element={<> <HomePage/> </>}/>
 
     </Routes>

         <ToastContainer
        position="top-right"
        autoClose={5000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        pauseOnHover
        draggable
      />
      </>
  )
  // }
}

export default App
