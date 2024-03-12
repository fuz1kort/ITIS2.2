import {useParams} from "react-router-dom";
import PokemonHeader from "./components/PokemonHeader";
import InfoBlocks from "./components/InfoBlocks";

const PokemonInfoPage = () => {
    const {name} = useParams()
    return <div>
        <PokemonHeader/>
        <InfoBlocks name={name}/>
    </div>
}

export default PokemonInfoPage
