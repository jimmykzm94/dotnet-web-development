import data from './weather.json'

function Weather(props){
    return(
    <table>
        <tbody>
        <tr>
            <th>Location</th>
            <th>Temperature</th>
            <th>Humidity</th>
            <th>Weather</th>
        </tr>
        {
            data.data.map( (d, index) => 
                <tr key={index}>
                    <td>{d.location}</td>
                    <td>{d.temperature}</td>
                    <td>{d.humidity}</td>
                    <td>{d.weather}</td>
                </tr>
            )
        }
        </tbody>
    </table>
    )
}

export default Weather;