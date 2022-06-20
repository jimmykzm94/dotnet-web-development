import {Component} from 'react'

class TempInput extends Component{
    constructor(props){
        super(props)
        this.handleTempChanged = this.handleTempChanged.bind(this);
        this.state = {temperature:''};
    }

    handleTempChanged(temperature){
        if (isNaN(temperature)){
            temperature = ''
        }
        this.setState({temperature})
    }    

    render(){
        return (
            <div>
                <UserInput onValueChanged={this.handleTempChanged}/>
                <DisplayMessage temperature={this.state.temperature}/>
            </div>
        );
    }
}

function UserInput(props){
    function handleChanged(e){
        props.onValueChanged(e.target.value);
    }

    return (
        <fieldset>
            <legend>Enter value:</legend>
            <input onChange={handleChanged}/>
        </fieldset>
    );
}

function DisplayMessage(props){
    return(
        <div>
            <p>Welcome, the temperature is {props.temperature}.</p>
        </div>
    )
}

export default TempInput;