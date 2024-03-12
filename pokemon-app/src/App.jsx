import './App.css';
import React from "react"
import SearchPage from "./views/SearchPokemonPage/SearchPage";
import {BrowserRouter, Route, Routes} from "react-router-dom";
import PokemonInfoPage from "./views/PokemonInfoPage/PokemonInfoPage";

function App() {
    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="/ITIS2.2" Component={SearchPage} />
                    <Route path="/" Component={SearchPage} />
                    <Route path="/pokemon/:name" Component={PokemonInfoPage} />
                </Routes>
            </BrowserRouter>
        </>
    );
}

export default App;
