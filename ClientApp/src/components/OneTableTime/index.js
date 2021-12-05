import React, { Component } from "react";

export default class OneTableTime extends Component {
    constructor(props) {
        super(props);
        this.state = {
            time: '',
            capacity: ''
        };
    }

    render() {
        return (
            <div>
                <button capacity={this.props.capacity} disabled={this.props.capacity === '0' ? true : ''}>{this.props.time}:00</button>
            </div>
        )
    }
}