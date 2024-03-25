import './App.css';
import React from "react"
import SearchPage from "./views/SearchPage";
import {BrowserRouter, Route, Routes} from "react-router-dom";

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
