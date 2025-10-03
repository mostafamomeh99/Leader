import {lazy} from 'react'
const ForgetPassword = lazy(() => import("../../Components/ForgetPassword/ForgetPssword"));

function ForgetPasswordPage(){


    return(<>
    <div style={{ background: "linear-gradient(to bottom, #16388F, #30CFD0)",backgroundSize: "cover", 
  backgroundPosition: "center" ,
  backgroundRepeat: "no-repeat",
  width: "100%",
  minHeight: "100vh",}}>
    <ForgetPassword/>
    </div>
    </>)
}

export default ForgetPasswordPage