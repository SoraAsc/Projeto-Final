import React from 'react';
import { View, Text, StyleSheet, TouchableOpacity, Image} from 'react-native';
import Icon from 'react-native-vector-icons/MaterialIcons';

export default function Header(props){
    //console.log(props)
    //Icon.loadFont();

    return (
        <View style={styles.header}>
            <Icon onPress={props.navigation.openDrawer} name="menu" size={28} color='#fff'/>
            <View>
                <Text style={styles.headerText}>
                    Sistema Solar
                </Text>
            </View>
            <Image style={styles.headerImage} source={require('./../assets/images/saturnoLogo.png')}></Image>
        </View>
    );
}


const styles = StyleSheet.create({
    header: {
        width: '100%',
        height: '100%',
        flexDirection: 'row',
        alignItems: 'center',
        justifyContent: 'space-between',
    },
    headerText: {
        fontWeight: 'bold',
        fontSize: 20,
        color: '#fff',
        letterSpacing: 1,
    },
    headerImage: {
        width:55,
        height:55,
    }
})