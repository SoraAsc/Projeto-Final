import React from 'react';
import {
  StyleSheet,
  Text,
  Image,
  View,
  FlatList,
  TouchableOpacity
} from 'react-native';


import Data from './../data/Database'

  export default function App(props){
    //console.log(props.navigation)
    return(

      <View style={styles.container}>
        <View style={styles.holderMainTopic}>
          <Image style={styles.mainTopLogo}
            source= {require('./../../assets/images/logov3.jpg')}
          ></Image>
        </View>
        <View style={styles.holderPlanetInfo}>
          <FlatList //style={{flex:1,flexBasis:1,}}
            data={Data}
            keyExtractor={ item=> item.id}
            showsVerticalScrollIndicator={false}
            //renderItem={TopiItem}
            renderItem = {({item}) =>(
              <View>
                <TouchableOpacity style={styles.containerButtonItem} activeOpacity={0.5}
                  onPress={() => props.navigation.navigate('Details',{data: item})}  
                >
                    <Image
                      source = {item.imageLink} 
                      style={styles.itemimage}
                    >
                    </Image>
  
                  <Text style={styles.itemtext}>{item.name}</Text>
  
                </TouchableOpacity>
              </View>
            )}
          >
          </FlatList>
        </View>
      </View>
    )
  }
  
  const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor:'red',
      flexDirection: 'column',
    },
    holderMainTopic: {
      backgroundColor: 'blue',
      flex: 0.5,
    },
    mainTopLogo: {
      width: '100%',
      height: '100%',    
      flexGrow: 1,      
    },
    holderPlanetInfo: {
      backgroundColor: 'green',
      flex: 0.5,
    },
  
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
  });
  
  