import React from "react";
import { useSearchParams } from "react-router-dom";

function Home() {
    let [searchParams, setSearchParams] = useSearchParams()
    searchParams.get("code")
    return (
        <div className="mx-auto">
            Стек: React + Bootstrap + MySQL + ASP.Net
            <div>Для навигации по сайту воспользуйтесь выпадающим меню.</div>
        </div>
        
    )
}

export default Home;