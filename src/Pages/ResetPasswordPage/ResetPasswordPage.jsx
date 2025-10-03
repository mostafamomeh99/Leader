
import {lazy} from 'react'

const ResetPassword = lazy(() => import("../../Components/ResetPassword/ResetPassword"));

function ResetPasswordPage(){


    return(<>
          <div style={{ background: "linear-gradient(to bottom, #16388F, #30CFD0)",backgroundSize: "cover", 
  backgroundPosition: "center" ,
  backgroundRepeat: "no-repeat",
  width: "100%",
  minHeight: "100vh",}}>
    <ResetPassword/>
    </div>
    </>)
}

export default ResetPasswordPage