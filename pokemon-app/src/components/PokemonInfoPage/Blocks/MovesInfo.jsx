import {PokemonMoveCard} from "./PokemonMoveCard";

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

