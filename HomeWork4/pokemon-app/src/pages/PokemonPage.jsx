import {useParams} from "react-router-dom";
import PokemonHeader from "../components/PokemonInfoPage/PokemonHeader";
import InfoBlocks from "../components/PokemonInfoPage/InfoBlocks";

const PokemonPage = () => {
    const {name} = useParams()
    return <div>
        <PokemonHeader/>
        <InfoBlocks name={name}/>
    </div>
}

export default PokemonPage
