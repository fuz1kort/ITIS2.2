import './App.css';
import React from "react"
import SearchPage from "./pages/SearchPage";
import {BrowserRouter, Route, Routes} from "react-router-dom";
import PokemonPage from "./pages/PokemonPage";

function App() {
    return (
        <>
            <BrowserRouter>
                <Routes>
                    <Route path="/ITIS2.2" Component={SearchPage} />
                    <Route path="/" Component={SearchPage} />
                    <Route path="/pokemon/:name" Component={PokemonPage} />
                </Routes>
            </BrowserRouter>
        </>
    );
}

export default App;
