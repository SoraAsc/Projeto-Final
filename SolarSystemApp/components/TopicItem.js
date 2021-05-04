import React from 'react';
import {View, Image, Text, StyleSheet} from 'react-native'

export default function TopicItem(){
    return (
        <View style={styles.container}>
            <Image 
                source={{uri:'https://p2.trrsf.com/image/fget/cf/940/0/images.terra.com/2019/12/21/105712269g742460.jpg'}}
                style={styles.image}
            >

            </Image>
            <Text>Algo</Text>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        backgroundColor: 'blue',
        flex: 1,
        flexDirection: 'row',
        alignItems: 'center',
    },
    image: {
        height: 300,
        flexGrow: 1,
        opacity: 0.4
    }

})
