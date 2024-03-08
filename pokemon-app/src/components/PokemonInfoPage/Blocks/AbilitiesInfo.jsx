const AbilitiesInfo = ({abilities}) => {
    return (
        <div className="info-card">
            <div className="info-card-wrapper">
                <div className="info-card-header">
                    <h2>Abilities</h2>
                </div>
                <div className="info-card-content">
                    <div className="abilities-list">
                        {abilities.slice(0, 2).map((ability) => <Ability key={ability} ability={ability} />)}
                    </div>
                </div>
            </div>
        </div>
    )
};

export default AbilitiesInfo

const Ability = (ability) => {
    const nameSplit = ability.ability.name.split('-');
    const name = nameSplit.map(word => word.charAt(0).toUpperCase() + word.slice(1)).join(' ');
    return(
        <div className={`ability slot-${ability.ability.slot}`}>
            <div className="ability-letter">
                <span className={`ability-letter-slot-${ability.ability.slot}`}>{name[0]}</span>
            </div>
            <span className="ability-name">{name}</span>
        </div>
    );
}