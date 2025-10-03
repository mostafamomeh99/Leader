import styles from "./StatsCard.module.css";

export default function StatsCard({ id,title,icon,value ,backColor , onCardClick }) {


// let FilterData=()=>{

// }

  return (
    <div className={styles.card} style={{backgroundColor: backColor}} onClick={() => onCardClick(id)} >
      <h6 style={{ color: "white" }}>{title}</h6>
     <div>{icon}</div> 
      <h3 style={{ color: "white" }}>{value}</h3>
    </div>
  );
}
