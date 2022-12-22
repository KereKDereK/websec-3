import React from "react";
import { useSearchParams } from "react-router-dom";

function Home() {
    let [searchParams, setSearchParams] = useSearchParams()
    searchParams.get("code")
    return (
        <div>
            HOME
        </div>
    )
}

export default Home;