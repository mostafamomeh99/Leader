import {lazy} from 'react'
const Login = lazy(() => import("../../Components/Login/Login"));

function LoginPage(){


    return(<>
    <div style={{ background: "linear-gradient(to bottom, #16388F, #30CFD0)",backgroundSize: "cover", 
  backgroundPosition: "center" ,
  backgroundRepeat: "no-repeat",
  width: "100%",
  minHeight: "100vh",}}>
    <Login/>
    </div>
    </>)
}

export default LoginPage