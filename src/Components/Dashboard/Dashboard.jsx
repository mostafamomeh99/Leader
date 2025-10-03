
import Sidebar from "../../Components/SideBar/SideBar";
import Topbar from "../../Components/TopBar/Topbar";
import StatsCard from "../../components/Cards/StatsCard";
import ClaimsChart from "../../Components/Chart/ClaimsChart";
import styles from "./Dashboard.module.css";

export default function Dashboard() {
  return (
    <div className={styles.layout}>
      <Sidebar />
      <div className={styles.main}>
        <Topbar />
        <div className="row mt-4">
          <div className="col-md-3"><StatsCard title="Product sold" value="25.1k" change="+15%" /></div>
          <div className="col-md-3"><StatsCard title="Total Profit" value="$2,435" change="-3.5%" /></div>
          <div className="col-md-3"><StatsCard title="Total No. of Claim" value="3.5M" change="+15%" /></div>
          <div className="col-md-3"><StatsCard title="New Customers" value="43.5k" change="+10%" /></div>
        </div>
        <div className="row mt-4">
          <div className="col-md-8"><ClaimsChart /></div>
          <div className="col-md-4">Sales team target Card هنا</div>
        </div>
      </div>
    </div>
  );
}
