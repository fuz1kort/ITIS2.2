import './App.css';
import React from "react"
import SearchPage from "./pages/SearchPage";
import {BrowserRouter} from "react-router-dom";

function App() {
    return (
        <>
            <BrowserRouter>
                <SearchPage/>
            </BrowserRouter>
        </>
    );
}

export default App;
