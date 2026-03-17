import react from 'react'
import TopBar from "./TopBar.jsx";
import BoxCenter from "./BoxCenter.jsx";
import DownBar from "./DownBar.jsx";

export default function CardBox() {

    return (
        <div className="cardbox">
            <TopBar />
            <BoxCenter />
            <DownBar />
        </div>
    )
}