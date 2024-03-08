import './App.css';
import React from "react"
import SearchPage from "./views/SearchPage";
import {BrowserRouter, Route, Routes} from "react-router-dom";
import PokemonPage from "./views/PokemonPage";

function App() {
    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<SearchPage/>} />
                    <Route path="/:name" element={<PokemonPage/>} />
                </Routes>
            </BrowserRouter>
        </>
    );
}

export default App;
