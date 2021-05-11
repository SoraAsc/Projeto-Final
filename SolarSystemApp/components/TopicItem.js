import React from 'react';
import {View, Image, Text, StyleSheet, TouchableOpacity} from 'react-native'

export default function TopicItem(props){
    //console.log(props.item)
    return (
        <View>
            <TouchableOpacity style={styles.containerButtonItem} activeOpacity={0.5}
                onPress={() => props.navigation.navigate('Details',{data: props.item})}
            >
                <Image source = {props.item.imageLink} style={styles.itemimage} />
  
                <Text style={styles.itemtext}>{props.item.name}</Text>  
            </TouchableOpacity>
        </View>
    )
}

const styles = StyleSheet.create({
    containerButtonItem: {
        backgroundColor: '#9300D6',
        flex: 1,
        flexDirection: 'row',
        alignItems: 'center',
        justifyContent: 'flex-end',    
    },
    itemimage: {
        width:'100%',
        height: 200,
        flexGrow: 1,
        opacity: 0.6
    },
    itemtext: {
        position: 'absolute', 
        right: 30,
        color: '#fff',
        fontWeight: 'bold',
        fontSize: 50,
    },
})
