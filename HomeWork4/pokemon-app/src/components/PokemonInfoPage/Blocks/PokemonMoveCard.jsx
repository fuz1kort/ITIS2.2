import typeToColor from "../../../utils/typesToColors";
import typeImages from "../../../utils/typeImages";
import {useEffect, useState} from "react";

export const PokemonMoveCard = ({move}) => {
    const [typeName, setTypeName] = useState("pokemon");
    const nameSplit = move.moveName.split('-');
    let newName = nameSplit.map(word => word.charAt(0).toUpperCase() + word.slice(1)).join(' ');
    useEffect(() => {
        fetch(`https://pokeapi.co/api/v2/move/${move.moveName}`)
            .then(res => res.json())
            .then(data => setTypeName(data.type.name))
    })
    
    return (
        <div
            style={{backgroundColor: typeToColor(typeName)}}
            className="pokemon-move-card">
            <div className="stats">
                <img src={typeImages[typeName]} alt={move.moveName}/>
                <span>{newName}</span>
            </div>
        </div>
    )
}