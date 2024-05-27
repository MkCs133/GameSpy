const { parseJSON } = require("jquery")

function GameDetails(games) {

    var gameInfo = parseJSON(games);

    <div class="gameDescription">
        <img src="/assets/Grand-Theft-Auto-V-Cover.svg" />
        <label id="gameName">
            gameInfo.Name
        </label>
        <label id="gameProducer">
            gameInfo.Manufacturer
        </label>
        <label id="gameRating">
            gameInfo.Rating + ★
        </label>
    </div>
}

