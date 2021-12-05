import React from 'react'
import OneTableTime from '../OneTableTime'

export const TableTimes = () => {
    return (
        <div>
            <OneTableTime time='0' capacity='0'/>
            <OneTableTime time='1' capacity='2'/>
            <OneTableTime time='2' capacity='7'/>
            <OneTableTime time='3' capacity='0'/>
            <OneTableTime time='4' capacity='0'/>
            <OneTableTime time='5' capacity='10'/>
            <OneTableTime time='6' capacity='5'/>
            <OneTableTime time='7' capacity='0'/>
            <OneTableTime time='8' capacity='1'/>
        </div>
    )
}