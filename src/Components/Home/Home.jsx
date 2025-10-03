import { lazy ,useState,useEffect} from "react";
const CircleIndicator=lazy(() => import("../CircleIndicator/CircleIndicator"));
const UploadExcel=lazy(() => import("../UploadExcel/UploadExcel"));
const StatsCard=lazy(() => import("../CallStatesCard/StatsCard"));
const TableData=lazy(() => import("../TableData/TableData"));
import FilterTable from "../FilertTable/FilterTable";
import { Api_URL } from "../../Resources/ApiUrl";
import { useTranslation } from "react-i18next";
function Home (){
  const {t,i18n}=useTranslation()
const language=i18n.language
const callStatuses = [
  { id: "123C61D3-DE6B-4385-BB40-0CE35ECB4625", nameAr: "غير ناجحة (التنبؤي)", nameEn: "Scheduled In Dialer" },//0
  { id: "29DC61D3-DE6B-4385-BB40-0CE35ECB4625", nameAr: "مجدولة تاريخياً (التنبؤي)", nameEn: "Scheduled In Dialer" },//1
  { id: "B8151E6F-6415-4B46-9B74-5DAE2E47D072", nameAr: "ناجحة", nameEn: "Success" },//2
  { id: "2CD4CC0E-AFBD-4A72-B930-8911662A4FCF", nameAr: "إعادة اتصال", nameEn: "Recall" },//3
  { id: "75BAD3F5-23CB-47E7-8485-A83E14E325D3", nameAr: "مسندة", nameEn: "Assigned" },//4
  { id: "0C027C7D-59A2-4319-A876-B22015611F97", nameAr: "مجدولة الآن", nameEn: "Queued In System" },//5
  { id: "DF1523DF-5FC3-41FC-A2D0-B3937CA4228F", nameAr: "غير ناجحة", nameEn: "Not Success" },//6
  { id: "9D7064B9-A41A-4B76-9889-D26750F3ECA6", nameAr: "مجدولة الآن (التنبؤي)", nameEn: "Queued In Dialer" },//7
  { id: "D252ADCD-CB7C-45BB-A1F7-D7905A14E348", nameAr: "مجدولة تاريخياً", nameEn: "Scheduled In System" }//8
];


  const [stats, setStats] = useState({});
const [filters, setFilters] = useState({}); // 🔹 هنا هنخزن الفلاتر اللي هتيجي من الكروت

   useEffect(() => {
    const fetchStats = async () => {
      try {
        const response = await fetch(`${Api_URL}/CP/v1.0/ScheduledCall/GetScheduledCallCountByCallStatus`, {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify({}) 
        });

        const data = await response.json();
        if (data?.succeeded && data?.data) {
          setStats(data.data);
        }
      } catch (error) {
        console.error("Error fetching stats:", error);
      }
    };

    fetchStats();
  }, []);


   const handleCardClick = (callStatusId) => {
    setFilters({
      callStatusId: callStatusId,
      idNumber: null,
      name: null,
      mobile: null,
      categoryId: null,
      campaignId: null,
      priorityId: null,
      callTypeId: null,
      scheduledCallDateRange: null,
      assignToUserId: null,
    });
  };


    // 🔹 البحث بالفلاتر (لو هتزود Inputs للبحث)
  const handleSearch = (appliedFilters) => {
    setFilters(appliedFilters);
    // fetchTableData(1, appliedFilters);
  };


    return(
        <>        

<CircleIndicator/>

        {/* Row of stat cards */}
<div className="row mt-4">
  <div className="col-xl-2 col-md-4 col-12 mt-2">
    <StatsCard title={language==='ar'?callStatuses[4].nameAr:callStatuses[4].nameEn} id={callStatuses[4].id}
      icon={<i style={{ color: "white" }} className="bi bi-headset fs-1"></i>} 
     value={stats?.assigned ?? "..."} backColor="#4A90E2" onCardClick={handleCardClick} />
  </div>

  <div className="col-xl-2 col-md-4 col-12 mt-2">
    <StatsCard title={language==='ar'?callStatuses[5].nameAr:callStatuses[5].nameEn} id={callStatuses[5].id}
      icon={<i style={{ color: "white" }} className="bi bi-list-task fs-1"></i>} 
        value={stats?.queuedInSystem ?? "..."}  backColor="#5DADE2" onCardClick={handleCardClick} />
  </div>

  <div className="col-xl-2 col-md-4 col-12 mt-2">
    <StatsCard title={language==='ar'?callStatuses[8].nameAr:callStatuses[8].nameEn} id={callStatuses[8].id}
      icon={<>
        <i style={{ color: "white" }} className="bi bi-stopwatch fs-4"></i>
        <i style={{ color: "white" }} className="bi bi-person fs-1"></i>
      </>}
             value={stats?.scheduledInSystem ?? "..."} backColor="#3498DB"  onCardClick={handleCardClick} />
  </div>

  <div className="col-xl-2 col-md-4 col-12 mt-2">
    <StatsCard title={language==='ar'?callStatuses[7].nameAr:callStatuses[7].nameEn} id={callStatuses[7].id}
      icon={<i style={{ color: "white" }} className="bi bi-list-task fs-1"></i>}
             value={stats?.queuedInDialer ?? "..."} backColor="#2E86C1" onCardClick={handleCardClick} />
  </div>

  <div className="col-xl-2 col-md-4 col-12 mt-2">
    <StatsCard title={language==='ar'?callStatuses[1].nameAr:callStatuses[1].nameEn} id={callStatuses[1].id}
      icon={<>
        <i style={{ color: "white" }} className="bi bi-stopwatch fs-4"></i>
        <i style={{ color: "white" }} className="bi bi-person fs-1"></i>
      </>}
     value={stats?.scheduledInDialer ?? "..."} backColor="#1F618D" onCardClick={handleCardClick} />
  </div>

  <div className="col-xl-2 col-md-4 col-12 mt-2">
    <StatsCard title={language==='ar'?callStatuses[0].nameAr:callStatuses[0].nameEn} id={callStatuses[0].id}
      icon={<i style={{ color: "white" }} className="bi bi-telephone-outbound-fill fs-1"></i>}
      value={stats?.notSuccessByDialer ?? "..."}  backColor="#154360" onCardClick={handleCardClick} />
  </div>
</div>

<UploadExcel />

   <FilterTable
 onSearch={handleSearch} 
      />

<TableData filters={filters}/>

        <div style={{height:"1000px"}}></div>
        
        
        </>
    )
}

export default Home