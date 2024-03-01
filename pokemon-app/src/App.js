import './App.css';
import {Route, Routes} from "react-router-dom";
import routes from "./utils/routes";
import PokemonDetailsPage from "./pages/PokemonDetailsPage";
import PokemonPage from "./pages/PokemonPage";

function App() {
  return (
      <div className="App">
        <Routes>
          {
            routes.map(i =>
                <Route path={i.path} element={i.component()}/>)
          }
          <Route path={"pokemon/:name"} element={<PokemonDetailsPage/>}/>
          <Route path="test" element={PokemonPage()}/>
        </Routes>
      </div>
  );
}

export default App;