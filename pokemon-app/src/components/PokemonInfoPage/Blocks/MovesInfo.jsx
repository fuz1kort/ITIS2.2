import {useEffect, useState} from "react";
import typeImages from "../../../utils/typeImages";
import typeToColors from "../../../utils/typesToColors";

const MovesInfo = ({moves}) => {
    if (!moves) {
        return <div></div>
    }

    moves = moves.slice(0, 6)

    return (
        <div className="info-card">
            <div className="info-card-wrapper">
                <div className="info-card-header">
                    <h2>Moves</h2>
                </div>
                <div className="info-card-content">
                    <div className="moves-list">
                        {moves.map(i => <PokemonMoveCard name={i.name} url={i.url}/>)}
                    </div>
                </div>
            </div>
        </div>
    )
};

export default MovesInfo

const PokemonMoveCard = ({name, url}) => {
    const [type, setType] = useState('')
    if (name.includes('-'))
        name = name.split('-').join(' ')

    useEffect(() => {
        fetch(url)
            .then(response => response.json())
            .then(json => setType(json.type.name))
    }, []);

    return (
        <div
            style={{backgroundColor: typeToColors[type]}}
            className="pokemon-move-card">
            <img src={typeImages[type]} alt={type}/>
            <p>{name}</p>
        </div>
    )
}