
import {lazy} from 'react'
const Otp = lazy(() => import("../../Components/Otp/OtpInput"));

function OtpPage(){


    return(<>
      <div style={{ background: "linear-gradient(to bottom, #16388F, #30CFD0)",backgroundSize: "cover", 
  backgroundPosition: "center" ,
  backgroundRepeat: "no-repeat",
  width: "100%",
  minHeight: "100vh",}}>
    <Otp/>
    </div>
    </>)
}

export default OtpPage