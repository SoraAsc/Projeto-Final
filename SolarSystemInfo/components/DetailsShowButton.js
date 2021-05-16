import React, {useState} from 'react';
import{
    TouchableOpacity,
    Text,
    StyleSheet,
} from 'react-native';

export default function DetailsShowButton(props){
    const [showInformation, setshowInformation] = useState(false)
    return(
        <TouchableOpacity style={styles.button} onPress={() => setshowInformation(!showInformation)}>
            <Text style={styles.text}>
                {!showInformation ? props.name : props.value}
            </Text>
        </TouchableOpacity>
    )
}

const styles = StyleSheet.create({
    button: {
        width: '100%',
        marginBottom: 2,
    },
    text:{
        color:'white',
        fontSize: 20,
        fontWeight: 'bold',
        textAlign: 'center',
    }
})
